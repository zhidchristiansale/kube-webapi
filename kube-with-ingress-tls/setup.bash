# Declare the names of the different resources here.
# Note: DNS Name should conform the regular expression: ^[a-z][a-z0-9-]{1,61}[a-z0-9]$.
$location_name = "eastus"
$resource_group_name = "practice_rg"
$public_ip_name = "practice_pip"
$dns_name = "practicekube"
$vnet_name = "practice_vnet"
$subnet_name = "practice_subnet"
$gateway_name = "practice_gateway"
$aks_name = "practice_aks"
$gateway_to_aks_peering = "gateway_to_aks"
$aks_to_gateway_peering = "aks_to_gateway"

# 1. Create the Networking Components required for the Application Gateway.

# az group create -n $resource_group_name -l $location_name

# 1.1 Create a Public IP Address with DNS name
az network public-ip create `
-g $resource_group_name `
--name $public_ip_name `
--version IPv4 `
--sku Standard `
--dns-name $dns_name

# 1.2 Create Azure Virtual Network
az network vnet create `
-n $vnet_name `
-g $resource_group_name `
--address-prefix 192.168.0.0/24 `
--subnet-name $subnet_name `
--subnet-prefix 192.168.0.0/24

# 2. Create the Application Gateway.
# Note: The hosts in the ingress.yaml should contain the Public IP Address of the gateway.

# 2.1 Create Application Gateway
az network application-gateway create `
-n $gateway_name `
-l $location_name `
-g $resource_group_name `
--sku Standard_v2 `
--public-ip-address $public_ip_name `
--vnet-name $vnet_name `
--subnet $subnet_name --priority 100

# 3. Set-up the Application Gateway Ingress Controller

# 3.1 Enable integration between the AKS Cluster and Application Gateway.
$appgwId = $(az network application-gateway show -n $gateway_name -g $resource_group_name -o tsv --query "id")

az aks enable-addons -n $aks_name -g $resource_group_name -a ingress-appgw --appgw-id $appgwId

# 3.2 Peer the Application Gateway network with the AKS network.

$nodeResourceGroup = $(az aks show -n $aks_name -g $resource_group_name -o tsv --query "nodeResourceGroup")

$aksVnetName = $(az network vnet list -g $nodeResourceGroup -o tsv --query "[0].name")

$aksVnetId = $(az network vnet show -n $aksVnetName -g $nodeResourceGroup -o tsv --query "id")

az network vnet peering create -n $gateway_to_aks_peering -g $resource_group_name --vnet-name $vnet_name --remote-vnet $aksVnetId --allow-vnet-access

$appGWVnetId = $(az network vnet show -n $vnet_name -g $resource_group_name -o tsv --query "id")

az network vnet peering create `
-n $aks_to_gateway_peering `
-g $nodeResourceGroup `
--vnet-name $aksVnetName `
--remote-vnet $appGWVnetId `
--allow-vnet-access

# 4. Install the Cert Manager.
# kubectl apply -f https://github.com/cert-manager/cert-manager/releases/download/v1.9.1/cert-manager.yaml

# 5. Install the Cert Issuer.
# kubectl apply -f cert-manager.yaml

# 6. Create the TLS Certificate and Secure the Ingress.
# kubectl apply -f ingress.yaml

# Notes: Use the following commands to check the status of the certificate:
# kubectl get certificate
# kubectl get certificaterequest
# kubectl describe certificaterequest
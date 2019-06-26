# Deployment of a service based on Azure App Service, Azure Function, Speech and LUIS Services

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fflecoqui%2FTestWebFunctionSpeechLuisApp%2Fmaster%2Fazuredeploy.json" target="_blank">
    <img src="http://azuredeploy.net/deploybutton.png"/>
</a>
<a href="http://armviz.io/#/?load=https%3A%2F%2Fraw.githubusercontent.com%2Fflecoqui%2FTestWebFunctionSpeechLuisApp%2Fmaster%2Fazuredeploy.json" target="_blank">
    <img src="http://armviz.io/visualizebutton.png"/>
</a>

This template allows you to deploy a Web Application on Azure App Service, several functions on Azure Function, a Speech Service and a LUIS service. Moreover, the applications and functions source code  will be stored on github and automatically deployed on Azure.


![](https://raw.githubusercontent.com/flecoqui/TestWebFunctionSpeechLuisApp/master/Docs/1-architecture.png)



## CREATE RESOURCE GROUP:

**Azure CLI:** azure group create "ResourceGroupName" "RegionName"

**Azure CLI 2.0:** az group create an "ResourceGroupName" -l "RegionName"

For instance:

    azure group create TestWebFunctionSpeechLuisApprg eastus2

    az group create -n TestWebFunctionSpeechLuisApprg -l eastus2

## DEPLOY THE SERVICES:

**Azure CLI:** azure group deployment create "ResourceGroupName" "DeploymentName"  -f azuredeploy.json -e azuredeploy.parameters.json*

**Azure CLI 2.0:** az group deployment create -g "ResourceGroupName" -n "DeploymentName" --template-file "templatefile.json" --parameters @"templatefile.parameter..json"  --verbose -o json

For instance:

    azure group deployment create TestWebFunctionSpeechLuisApprg TestWebFunctionSpeechLuisAppdep -f azuredeploy.json -e azuredeploy.parameters.json -vv

    az group deployment create -g TestWebFunctionSpeechLuisApprg -n TestWebFunctionSpeechLuisAppdep --template-file azuredeploy.json --parameter @azuredeploy.parameters.json --verbose -o json


When you deploy the service you can define the following parameters:</p>
**webSiteName:**                    The name of the web site (must be unique) </p>
**hostingPlanName:**                The name of the hosting Plan (must be unique)</p>
**skuName:**                        The Sku Name, by default "S1". Use S1 to get the connection between the App Service and the VNET</p>
**skuCapacity:**                    The Sku Capacity, by defualt 1</p>
**sqlServerName:**                  The SQL Server Name (must be unique)</p>
**databaseName:**                   The database Name (must be unique)</p>
**sqlAdministratorLogin:**          The SQL Administrator Login</p>
**sqlAdministratorLoginPassword:**  The SQL Administrator Password (Complexe password required)</p>
**nsgName:**                        The Network Security Group Name</p>
**virtualNetworkName:**             The Virtual Network Name</p>
**subnetName:**                     The Subnet Name</p>
**storageAccountName:**             The Stoarage Account Name</p>
**repoURL:**                        The github repository url</p>
**branch:**                         The branch name in the repository</p>

## TEST THE SERVICES:
Once the services are deployed, you can open the Web page hosted on the Azure App Service.
For instance :

     http://<websitename>.azurewebsites.net/
 
</p>


## DELETE THE RESOURCE GROUP:

**Azure CLI:** azure group delete "ResourceGroupName" "RegionName"

**Azure CLI 2.0:** az group delete -n "ResourceGroupName" "RegionName"

For instance:

    azure group delete TestWebFunctionSpeechLuisApprg eastus2

    az group delete -n TestWebFunctionSpeechLuisApprg 


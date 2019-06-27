# Deployment of a service based on Azure App Service, Azure Function, Azure Search, Azure Storage, Speech and LUIS Services

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fflecoqui%2FTestWebFunctionSpeechLuisApp%2Fmaster%2Fazuredeploy.json" target="_blank">
    <img src="http://azuredeploy.net/deploybutton.png"/>
</a>
<a href="http://armviz.io/#/?load=https%3A%2F%2Fraw.githubusercontent.com%2Fflecoqui%2FTestWebFunctionSpeechLuisApp%2Fmaster%2Fazuredeploy.json" target="_blank">
    <img src="http://armviz.io/visualizebutton.png"/>
</a>

This template allows you to deploy a Web Application on Azure App Service, several functions on Azure Function, an Azure Storage Account, Azure Search Account, a Speech Service and a LUIS service. Moreover, the applications and functions source code  will be stored on github and automatically deployed on Azure.


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
**namePrefix:**						The name prefix which will be used for all the services deployed with this ARM Template</p>
**storageSku:**                     The Storage Sku Capacity, by default Standard_LRS</p>
**searchSku:**						The Search Sku Capacity, by default free</p>
**customSpeechSku:**                The Custom Speech Sku Capacity, by default F0</p>
**luisSku:**						The LUIS Sku Capacity, by default F0</p>
**WebAppSku:**						The WebApp Sku Capacity, by defualt F1</p>
**azFunctionAppSku:**				The Azure Function App Sku Capacity, by defualt F1</p>
**repoURL:**                        The github repository url</p>
**branch:**                         The branch name in the repository</p>

Once deployed, the following services are available in the resource group:


![](https://raw.githubusercontent.com/flecoqui/TestWebFunctionSpeechLuisApp/master/Docs/1-deploy.png)


## TEST THE SERVICES:
Once the services are deployed, you can open the Web page hosted on the Azure App Service.
For instance :

     http://<websitename>.azurewebsites.net//WebApp/WebApp.html
 
With Curl you can test the Azure Functions:
For instance :

     curl -d "{}" -H "Content-Type: application/json"  -X POST   https://testspeechfunction.azurewebsites.net/api/Function1App
     curl -d "{}" -H "Content-Type: application/json"  -X POST   https://testspeechfunction.azurewebsites.net/api/Function2App

</p>


## DELETE THE RESOURCE GROUP:

**Azure CLI:** azure group delete "ResourceGroupName" "RegionName"

**Azure CLI 2.0:** az group delete -n "ResourceGroupName" "RegionName"

For instance:

    azure group delete TestWebFunctionSpeechLuisApprg eastus2

    az group delete -n TestWebFunctionSpeechLuisApprg 


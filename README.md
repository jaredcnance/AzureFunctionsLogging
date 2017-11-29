# Logging in Pre-Compiled Azure Functions

### Pre-Requisites

- [func.exe](https://github.com/Azure/azure-functions-cli)

### Running

1. `git clone https://github.com/jaredcnance/AzureFunctionsLogging.git`
2. cd `./AzureFunctionsLogging/AzureFunctionsLogging`
3. `dotnet build` or `msbuild.exe`
4. `func host start`
5. Send request:

#### Serilog

```
curl -X POST \
  http://localhost:7071/api/serilog \
  -H 'content-type: application/json' \
  -d '{}'
 ```

#### log4net

 ```
 curl -X POST \
  http://localhost:7071/api/log4net \
  -H 'content-type: application/json' \
  -d '{}'
 ```

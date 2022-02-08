#cd cryptotps.frontend
curl -o api-def.json http://localhost:20202/swagger/v1/swagger.json
openapi-generator-cli generate -g javascript -i api-def.json -o src/services/api-gen
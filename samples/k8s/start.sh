kubectl create ns app-dev

kubectl apply -f ./config-map/

helm delete -n app-dev demo-healthcheck
helm delete -n app-dev demo-gateway
helm delete -n app-dev demo-api1
helm delete -n app-dev demo-api2

helm install -n app-dev demo-healthcheck ./demo-healthcheck
helm install -n app-dev demo-gateway ./demo-gateway
helm install -n app-dev demo-api1 ./demo-api1
helm install -n app-dev demo-api2 ./demo-api2
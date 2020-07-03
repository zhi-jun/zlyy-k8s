kubectl create ns infrastructure
# kubectl create secret docker-registry registrykey -n app-dev infrastructure --docker-server=hub.iflytek.com --docker-username=zjzhang2 --docker-password=xxx --docker-email=zjzhang2@iflytek.com
# kubectl create secret tls ingress-tls -n infrastructure --key ./nginx/iflyhealth.com.key --cert ./nginx/iflyhealth.com.crt
kubectl apply -f ./ingress/
kubectl apply -f ./efk/
kubectl apply -f ./nginx/
kubectl apply -f ./monitor/
kubectl apply -f ./pvc/
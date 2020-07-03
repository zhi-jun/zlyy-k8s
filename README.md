# k8s基础架构

## 目录

    ├── infrastructure                  基础设施
    │   ├── efk                         efk日志组件
    │   ├── ingress                     ingress
    │   ├── monitor                     监控面板
    │   ├── nginx                       nginx
    │   ├── pvc                         持久卷    
    ├── samples                         简单案例
    │   ├── k8s                         部署yaml   
    │   ├── source                      源代码

+ docker+k8s安装 [参考地址](http://note.youdao.com/noteshare?id=ab3eb1f3c833cb2db5d9436bda3e24d9)

+ helm安装
```shell
wget -O helm.tar.gz https://get.helm.sh/helm-v3.0.0-linux-amd64.tar.gz
tar zxvf helm.tar.gz
sudo cp linux-amd64/helm /usr/bin/
helm version
```

+ 常用命令
```shell
kubectl apply/delete -f xxx.yaml  #安装/删除 k8s应用
kubectl apply/delete -f ./        #安装/删除 k8s应用 当前目录下所有yaml
helm delete -n <ns-name> <app-name>  #删除 helm软件包
helm install -n <ns-name> <app-name> ./ #安装 helm软件包 注: Chart.yaml所在目录
```

+ 镜像仓库 [仓库地址](https://hub.iflytek.com/)
```
创建secret:
kubectl create secret docker-registry registrykey -n <ns-name>
--docker-server=hub.iflytek.com --docker-username=xxx --docker-password=xxx docker-email=xxx@iflytek.com
k8s推送镜像时使用secret:
deployment/spec/template/spec/imagePullSecrets/name: registrykey
```

+ 一键部署
```
./infrastructure/start.sh
./samples/k8s/start.sh
```

+ kibana使用 [参考地址](http://note.youdao.com/noteshare?id=2ec4e8823bb7b775a27d563189cf78fa)

+ grafana使用 [参考地址](http://note.youdao.com/noteshare?id=5853896070d7bc4da68e396c3c38ff1d)
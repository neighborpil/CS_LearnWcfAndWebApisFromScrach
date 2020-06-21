WCF
===
# What is?
 - Windows Communication Foundation
 - Unified programming model for writing distributed application on the Microsoft platform.
 - SDK for developing and deploying services on Windows


----------------------------
1. Creating a service

2. Hosting a service

3. Consuming a service

- wcf는 위으 세가지로 구성된다고 보면 된다.

서비스를 생성하고

빌드 후 실행하면 .net 프레임워크?가 자동으로 웹서비스를 호스팅해준다.

그러면 웹 주소를 통하여 사용하기만 하면 끝이다.


- 서비스 생성은 기본 인터페이스와 인터페이스를 구현하는 클래스로 구성된다.

Interface는 world에 노출되고, class에 구현한 것을 실행한다.

--------------------------
# SOA
* Service Oriented Architecture
 - reusable component on the network
 - collection of services on a network that communicate with one another
 - Services are well-defined, platform-independent interfaces and reusable

![SOA](./soa.jpg)


# Web Service
 - A web service is a unit of managed code that can be remotely invoked using HTTP

# End Points(ABCs)
 - End Points are alos called as ABCs of services;
 - A stands for Address(127.0.0.1)
 - B stands for Binding(http, net.tcp, net.pipe, net.msmq)
 - C stands for Contract(Interfaces and Methods)
 - Server side의 abc와 Client side의 abc가 일치해야 한다

```
    // Server side
    <service name="MultipleWcfServiceLibrary.MultipleService" behaviorConfiguration="MyServiceTypeBehaviors">
        <endpoint 
	    address="http://localhost:11987/MyMultipleServiceHost.svc"
	    binding="basicHttpBinding" bindingConfiguration="" 
	    contract="MultipleWcfServiceLibrary.IMultipleService" />
    </service>

    // Client side
    <endpoint 
        address="http://localhost:11987/MyMultipleServiceHost.svc"
        binding="basicHttpBinding" bindingConfiguration="BasicHttpBinding_IMultipleService"
        contract="MultipleServiceReference.IMultipleService" name="BasicHttpBinding_IMultipleService" />
```
-------------
# Hosting options
 - WCF를 hosting 할 수 있는 방법은 4가지이다.

## 1. Self-Hosting in a Managed Application
  - 아래의 3가지 방법 중 하나를 사용하여 c#코드를 작성하는 것을 의미
    - Console Application
    - Windows Form Application
    - WPF Application
## 2. Managed Windows Service

## 3. Internet Information Services(IIS)

## 4. Windows Process Activation Service(WAS)
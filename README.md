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

- wcf�� ���� �������� �����ȴٰ� ���� �ȴ�.

���񽺸� �����ϰ�

���� �� �����ϸ� .net �����ӿ�ũ?�� �ڵ����� �����񽺸� ȣ�������ش�.

�׷��� �� �ּҸ� ���Ͽ� ����ϱ⸸ �ϸ� ���̴�.


- ���� ������ �⺻ �������̽��� �������̽��� �����ϴ� Ŭ������ �����ȴ�.

Interface�� world�� ����ǰ�, class�� ������ ���� �����Ѵ�.

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
 - Server side�� abc�� Client side�� abc�� ��ġ�ؾ� �Ѵ�

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
 - WCF�� hosting �� �� �ִ� ����� 4�����̴�.

## 1. Self-Hosting in a Managed Application
  - �Ʒ��� 3���� ��� �� �ϳ��� ����Ͽ� c#�ڵ带 �ۼ��ϴ� ���� �ǹ�
    - Console Application
    - Windows Form Application
    - WPF Application
  - To manage the host life cycle i.e., creating and opening an instance of the **ServiceHost** class to make the service available and closing the instance after use.
    - ȣ������ �� �� ���� ���� ���� ���� ������ �������� �ؾ��Ѵ�.(IIS���� ���� �ڵ����� ���ش�)
  - ���� �ܰ迡�� ���. �����͸� Ʈ���̽� �ϱ� ����, ���ø����̼� ���ο��� � ���� �Ͼ���� �� �� �ִ�. ���� Debuging�� ����.(����� �뵵?)
  - ���߽� �ֿܼ��� �ϰ� Windows Services�� �Ѿ
  - Protocol : http, net.tcp, net.pipe, net.msmq
  - ����
    1. Adding dlls
    2. Adding references
    3. Create the ServiceHost
    4. Adding an End-Point(�ڵ忡�� ���ų� ����(Web.config)����)
    5. Enalbe service metadata behavior
    6. Open service(Start listening for clients)
    7. Close service(Stop listening for clients)
 - MEX Endpoint(Metadata Exchange)
   �ΰ��� ���� �� �ִ� ����� �ƴ� ������� ���?
 - svcutil�� ���
   - Proxy Class�� �����
   - Microsoft Visual Studio Command Prompt�� ������ �������� �����ϰ� svcutil net.tcp://localhost:50011/mex /out:"D:MyProxy.cs" /config:"D:MyProxy.config"�� �ϸ� ���Ͻ� Ŭ������ �� �� �ִ�

## 2. Managed Windows Service
 - Microsoft Windows services(=NT services)
   - Windows sessions ������ ����
   - enables to create long-running executable applications
   - can be automatically started when the computer boots, can be paused and restarted, and do not show any user interface
     - SQL servicesó�� �ѹ� �����ϸ� ������� �ص� OS���Ͽ� �ڵ� ����� �� ���
   - IIS�̿ܿ� WCF service�� ��ð� ��� �� ���
   - ����
     - �ѹ� OS�� ���� ��ǰ� ����۵�
     - ���� �߻��� �ڵ����� Windows Service Control Manager�� ���� ����۵�
     - Secure enviroment
   - ����
     - ��ġ�ؾ� ��
  - Protocol : http, net.tcp, net.pipe, net.msmq

 - how to do
 ![managed_windows_service_implementation](./managed_windows_service_implementation.jpg)

## 3. Internet Information Services(IIS)

## 4. Windows Process Activation Service(WAS)
 - new process activation service that is generalization of IIS features that work with non-HTTP transport protocols
 - Such as Tcp, named pipes, and Message Queuing
 - ������ڸ� IIS(IIS 7 �̻�)���� �����ϴ� non-HTTP binding�� ���� WCF services �̴�.


# IIS ��ġ
 1. �������� ��� �Ѱ� ����
 2. ���ͳ� ���� ����
 3. ���� ���α׷� ���� ���
 4. ASP.NET 4.8
 5. ������ �˻�â���� inetmgr ġ�� ISS ���� �г� ����


# Binding
 - ���ӿ� ���� ���� ����
 - App.config -> ��Ŭ�� -> Edit WCF Configuration�� ���Ͽ� ���� ����
 - �ڵ忡���� ���� ����

# Contract
 - Ŭ���̾�Ʈ�� service���� ������ �� �� �ִ� ���� ��Ÿ��, capability or feature set
 - �޽��� ���� ���� ���� : json , xml��
 - Type of contract
   - Service contract : Ŭ���̾�Ʈ�� service���� ������ �� �� �ִ� ��
   - Data contract : � �����͸� �ְ� �������� ����
   - Fault contract : ����, ��� �ڵ鸵
   - Message contract : �޽��� ������ ���Ͽ� �̱���(interoperability)���� ��Ű����ϰ� ��, ���� ��� X
 - ���� ��� ����

# Service Client Proxy?
 - ���� ���̺귯������ ServiceContract�� OperationContract�� Name�� �ٲٴ� ��
 - ���񽺿����� �����ε��� �������� �ʱ� ������ �̸� ���Ͽ� �޼��� �̸��� �ٲپ� ���� �Ѵ�.
 - [ServiceContract(Name="MultiplicationService")]
 - [OperationContract(Name ="MulInt")]

# Data Contract
 - �⺻ �ڷ���(int, double, ...)�� �ڵ����� Serialization �ǰ� Deserialization�ȴ�.
 - ������ Array ���� ��ü�� �ڵ����� ������� �ʱ� ������ ���ǰ� �ʿ��ϴ�.
 - �� ���Ǹ� ���ִ� ���� Data Contract�̴�.
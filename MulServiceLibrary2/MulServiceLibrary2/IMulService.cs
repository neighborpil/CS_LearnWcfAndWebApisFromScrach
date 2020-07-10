using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MulServiceLibrary2
{
    [ServiceContract(Name="MultiplicationService")]
    public interface IMulService
    {
        /*
         * # 함수를 추가/삭제 할 때마다 서비스를 불러오거나 오류가 발생하는 경우가 생긴다
         *   기본은 기존의 서비슨느 건드리지 않는 방식으로 가야 한다.
         *
         *
         * int Mul(int a);
         * 만약 서비스라이브러리의 함수에 두번째 파라미터를 삭제하고
         * 클라이언트에서 아직 업데이트가 안되어 두번째 파라미터가 프록시 클래스에 남아 있을 수 있다
         * 그럴 경우 두번째 파라미터는 그냥 무시된다.
         *
         * int Mul(int a, int b, int c);
         * 만약 서비스 라이브러리에의 함수에 세번째 파라미터를 추가하고
         * 클라이언트에서 아직 업데이트가 안되어 세번째 파라미터가 프록시 클래스에 할당하지 않을 경우
         * 에러는 나지 않는데 제대로 된 값을 받지 못한다
         *
         * double Mul(int a, int b);
         * 리턴값을 바꿀경우 정상 동작
         *
         *
         * int Add(int a, int b);
         * 새로운 함수를 추가할 경우 정상 동작
         */
        [OperationContract]
        int Mul(int a, int b);

        //// Name을 쓰는 이유는 오버로딩에서 유용하기 때문
        //[OperationContract(Name = "Multiply")]
        //int Mul(int a, int b);

        [OperationContract]
        int Add(int a, int b);
    }
}

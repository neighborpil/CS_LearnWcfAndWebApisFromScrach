using System;
using System.Data;

namespace InterfaceLib.Database
{
    public interface IDatabase : IDisposable
    {
        /// <summary>
        /// 데이터 조회
        /// </summary>
        /// <param name="query">쿼리문</param>
        /// <returns>결과 데이터 테이블</returns>
        DataTable GetData(Query query);

        /// <summary>
        /// 데이터 입력
        /// </summary>
        /// <param name="query">쿼리문</param>
        /// <param name="needLastInsertedId">결과값으로 마지막 입력값을 받을지 결정</param>
        /// <returns>needLastInsertedId값이 true라면 마지막 입력한 값의 id, false라면 입력한 열수</returns>
        long SetData(Query query, bool needLastInsertedId = false);
    }
}
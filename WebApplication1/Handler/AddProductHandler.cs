using Dapper;
using MediatR;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Command;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Handler
{
    public class AddProductHandler : IRequestHandler<AddProductCommandcs, Response<object>>
    {
        public readonly IConfiguration _config;

        public AddProductHandler(IConfiguration config) => _config = config;


        public Response<T> ExcuteCommand<T>(string query, DynamicParameters param, string dbcon)
        {
            Response<T> response = new Response<T>();
            using (IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString(dbcon)))
            {
                if (dbConnection.State == ConnectionState.Closed)
                    dbConnection.Open();
                using var transaction = dbConnection.BeginTransaction();
                try
                {
                    response.Data = dbConnection.Query<T>(query, param, commandType: CommandType.StoredProcedure, transaction: transaction).FirstOrDefault();
                    response.Code = 200;
                    response.Message = "Success";
                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                    response.Code = 500;
                    response.Message = ex.Message;
                }


            }
            return response;
        }

        public async Task<Response<object>> Handle(AddProductCommandcs request, CancellationToken cancellationToken)
        {
            Response<object> response = new Response<object>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("Id", request.product.Id, DbType.Int32);
                param.Add("Name", request.product.Name, DbType.String);
                param.Add("retval", DbType.Int32, direction: ParameterDirection.Output);

                var result = ExcuteCommand<object>("usp_InsertProduct", param, "CoreDb");
                if (result.param?.Get<int>("retval") == 100)
                {
                    response.Data = result.Data;
                    response.Code = 200;
                    response.Message = "Success";
                }
                else
                {
                    response.Data = null;
                    response.Code = -200;
                    response.Message = "Failed";
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Code = 500;
                response.Message = ex.Message;
            }

            return response;

        }

    }
}

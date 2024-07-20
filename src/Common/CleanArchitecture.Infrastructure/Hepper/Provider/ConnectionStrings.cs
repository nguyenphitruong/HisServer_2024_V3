using Microsoft.Extensions.Options;

namespace Emr.Infrastructure.Hepper.Provider
{
    public class ConnectionStrings
    {
        public static string DefaultConnection { get; set; }
        public static string DefaultConnection_Sqlite { get; set; }

        // Tham số khởi tạo là IOptions, các tham số khởi tạo khác nếu có khai báo như bình thường
        public ConnectionStrings(IOptions<ConnectionStringOptions> options)
        {
            // Đọc được MyServiceOptions từ IOptions
            ConnectionStringOptions opts = options.Value;

            DefaultConnection = opts.DefaultConnection;
            DefaultConnection_Sqlite = opts.DefaultConnection_Sqlite;
        }
    }
}

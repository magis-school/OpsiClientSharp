using System.Threading.Tasks;
using MagisIT.OpsiClient.Models;

namespace MagisIT.OpsiClient.RpcInterfaces
{
    public class DepotInterface : RpcInterface<DepotInterface>
    {
        public override string InterfaceName => "depot";

        public DepotInterface(OpsiHttpClient opsiHttpClient) : base(opsiHttpClient) { }

        /// <summary>
        /// Returns a md5 sum of a file in the depot
        /// </summary>
        /// <param name="absoluteFilePath">The absolute file path to the file. Usually /var/lib/opsi/repository</param>
        /// <returns>The md5Sum of the file</returns>
        public Task<string> GetMd5SumAsync(string absoluteFilePath)
        {
            return OpsiHttpClient.ExecuteAsync<string>(
                new Request(GetFullMethodName("getMD5Sum")).AddParameter(absoluteFilePath)
            );
        }

        /// <summary>
        /// Installs an opsi package.
        /// This method returns as soon as the installation is fully completed
        /// </summary>
        /// <param name="absoluteFilePath"></param>
        /// <param name="timeout">The timeout to wait until the product is installed. We don't have any status update only if an error appears. Another solution would be to use the SSH Command or check the logs</param>
        /// <returns>Nothing if successful otherwise an exception</returns>
        public Task InstallPackageAsync(string absoluteFilePath, int timeout = 180)
        {
            return OpsiHttpClient.ExecuteAsync<string>(
                new Request(GetFullMethodName("installPackage")).AddParameter(absoluteFilePath),
                timeout
            );
        }

        /// <summary>
        /// Uninstalls an opsi package
        /// </summary>
        /// <param name="productId">The product id which should be uninstalled</param>
        /// <param name="timeout">The timeout to wait until the product is uninstalled. We don't have any status update only if an error appears. Another solution would be to use the SSH Command or check the logs</param>
        /// <returns>Nothing if successful otherwise an exception</returns>
        public Task UninstallPackageAsync(string productId, int timeout = 180)
        {
            return OpsiHttpClient.ExecuteAsync<string>(
                new Request(GetFullMethodName("uninstallPackage")).AddParameter(productId)
            );
        }
    }
}

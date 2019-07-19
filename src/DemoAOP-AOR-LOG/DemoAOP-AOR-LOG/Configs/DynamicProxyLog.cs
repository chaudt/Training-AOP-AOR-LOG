using Castle.DynamicProxy;
using System;
using System.Linq;

namespace DemoAOP_AOR_LOG.Configs
{
    public class DynamicProxyLog : IInterceptor
    {
        public DynamicProxyLog()
        {

        }
        public void Intercept(IInvocation invocation)
        {
            var name = $"{invocation.Method.DeclaringType}.{invocation.Method.Name}";
            var args = string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()));
            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                invocation.Proceed(); //Intercepted method is executed here.
            }
            catch (Exception ex)
            {

                System.IO.File.AppendAllText("StudentServiceLog.log", ex.ToString());
            }
            

            watch.Stop();
            var executionTime = watch.ElapsedMilliseconds;
            var output = invocation.ReturnValue;
        }
    }
}

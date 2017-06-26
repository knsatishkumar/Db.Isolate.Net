using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Isolate
{
    public class AutoGenerateOrmClass
    {
        public Type GenerateClass(string tableName , List<string> columns)
        {
            StringBuilder classBuilder = new StringBuilder();
            classBuilder.Append(String.Format(" public class {0} ", tableName));
            classBuilder.Append(String.Format(" {0} ", "{"));
            foreach (var item in columns)
            {                
                classBuilder.Append(String.Format(@" public string {0} {{ get; set; }} ", item));
            }
            classBuilder.Append(String.Format(" {0} ", "}"));
            string stringClassCode = classBuilder.ToString();
            using (Microsoft.CSharp.CSharpCodeProvider foo =
           new Microsoft.CSharp.CSharpCodeProvider())
            {
                var res = foo.CompileAssemblyFromSource(
                    new System.CodeDom.Compiler.CompilerParameters()
                    {
                        GenerateInMemory = true
                    },
                    stringClassCode
                );
                return res.CompiledAssembly.GetType(tableName);
            }
        }
    }
}

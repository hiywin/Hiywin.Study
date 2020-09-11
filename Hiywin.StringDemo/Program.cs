using System;
using System.Text;

namespace Hiywin.StringDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Test();

            Console.Read();
        }

        static void Test()
        {
            StringBuilder builder = new StringBuilder();

            string aa = "哈哈";
            int bb = 10;
            bool cc = true;
            string ee = null;
            StringAdd(builder, aa);
            StringAdd(builder, bb);
            StringAdd(builder, cc);
            StringAdd(builder, ee);

            string formater = " haha:{0} ";
            StringAdd1(builder, formater, ee);
        }

        static void StringAdd1(StringBuilder builder, string formater, object condition)
        {
            switch (condition?.GetType()?.Name)
            {
                case "String":
                    if (!string.IsNullOrEmpty(condition.ToString()))
                    {
                        builder.Append(string.Format(formater, condition));
                    }
                    break;
                case "Int32":
                    builder.Append(condition);
                    break;
                case "Boolean":
                    builder.Append(condition);
                    break;
                default:
                    break;
            }
        }

        static void StringAdd(StringBuilder builder,object condition)
        {
            var aa = condition?.GetType();

            var dd = condition?.GetType()?.Name;

            if (dd == "String")
            {
                var ee = condition.ToString();
            }

            if (dd == null)
            {
                Console.WriteLine(dd);
            }

            switch (dd)
            {
                case null:
                    Console.WriteLine("1111");
                    break;
                default:
                    break;
            }

            Console.WriteLine(dd);
        }
    }
}

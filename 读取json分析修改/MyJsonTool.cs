using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Data;

namespace 读取json分析修改
{
    public class MyJsonTool
    {
        public string inputFilePath = "package\\";
        public string outputFilePath = "package2\\";
        JObject jsonObject;
        public Dictionary<string, MyJsonSet> jsonDesc = new Dictionary<string, MyJsonSet>();

        public void init()
        {
            jsonDesc = new Dictionary<string, MyJsonSet>();
            string[] strs = File.ReadAllLines("aaaagq.txt");
            MyJsonSet myJsonSet = new MyJsonSet(); ;
            for (int i = 0; i < strs.Length; i++) 
            {
                string str = strs[i].Trim();
                if (str.StartsWith("//")) continue;
                str = str.Replace('，', ',').Replace('：', ':');
                //文件：js.json
                //解释：角色 声望 1 金额 1 雇用
                //列26，赋值，1
                //列26，乘，10
                if (str.StartsWith("文件:"))
                {
                    myJsonSet = new MyJsonSet();
                    str = inputFilePath + str.Replace("文件:", "");
                    if (jsonDesc.ContainsKey(str))
                        myJsonSet = jsonDesc[str];
                    else jsonDesc.Add(str, myJsonSet);
                }
                else if (str.StartsWith("解释:"))
                {
                    str = str.Replace("解释:", "");
                    myJsonSet.desc = str;
                }
                else if (str.StartsWith("列"))
                {
                    myJsonSet.coms.Add(str);
                }

            }
        }

        public void runCOM(string FileName)
        {
            if (!jsonDesc.ContainsKey(FileName)) return;

            MyJsonSet myJsonSet = jsonDesc[FileName];
            if (myJsonSet.coms.Count == 0) return;

            load(FileName);
            for (int i = 0; i < myJsonSet.coms.Count; i++) 
            {
                string[] strs = myJsonSet.coms[i].Split(',');
                string str2 = strs[0].Substring(1, strs[0].Length-1);
                int n = int.Parse(str2);
                if (strs[1] == "赋值") BatchModifyJsonMov(n, strs[2]);
                else if (strs[1] == "乘") BatchModifyJsonMul(n, double.Parse(strs[2]));
            }
            save(FileName);
           
        }
        public string getJsonSetdesc(string FileName)
        {
            string str = "文件:" + FileName + Environment.NewLine;
            str += "解释:" + jsonDesc[FileName].desc + Environment.NewLine;
            str += String.Join(Environment.NewLine, jsonDesc[FileName].coms);
            return str;
        }

        public DataTable jsonGetdt(string FileName)
        {
            string json = File.ReadAllText(FileName);
            jsonObject = JObject.Parse(json);
            DataTable dt = new DataTable();

            if (!jsonObject.ContainsKey("data")) return dt ;

            int maxi = 0;
            foreach (JArray obj2 in jsonObject["data"][0])
                maxi++;

            for (int i = 0; i < maxi; i++)
                dt.Columns.Add(new DataColumn(i.ToString(), typeof(string)));

            foreach (JArray obj in jsonObject["data"])
            {
                DataRow row = dt.NewRow();
                int i = 0;
                foreach (JArray obj2 in obj)
                {
                    row[i] = obj2[0].ToString();
                    i++;
                    if (i >= 50) break;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
        public void load(string FileName)
        {
            string json = File.ReadAllText(FileName);
            jsonObject = JObject.Parse(json);
        }
        public void save(string FileName)
        {
            string FileNamenew = outputFilePath + FileName.Substring(inputFilePath.Length, FileName .Length- inputFilePath.Length);
            string modifiedJson = jsonObject.ToString();
            File.WriteAllText(FileNamenew, modifiedJson, System.Text.Encoding.UTF8);
        }
        public void BatchModifyJsonMul(int n1, double n2)
        {
            foreach (JArray obj in jsonObject["data"])
            {
                if (obj[n1][0].ToString() == "") continue;
                double d = double.Parse(obj[n1][0].ToString()) * n2;
                if (n2 < 1 && d < 1 && d > 0) d = 1;
                obj[n1][0] = d;
            }
        }
        public void BatchModifyJsonMov(int n1, string str3)
        {
            foreach (JArray obj in jsonObject["data"])
            {
                obj[n1][0] = str3;
            }
        }
        public class MyJsonSet
        {
            public string desc = "";
            public List<string> coms = new List<string>();
        }
    }

}

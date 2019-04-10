using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaiwellFuture.ViewModels
{
    /// <summary>
    /// 工程查看
    /// </summary>
    public class ProjectViewModel
    {
        /// <summary>
        /// 工程文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 工程名称
        /// </summary>
        public string ProjectName { get; set; }
        public string HMIOrPC { get; set; }
        /// <summary>
        /// 数据库版本
        /// </summary>
        public string DbSchemaVersion2 { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 创建的组态版本
        /// </summary>
        public string CloudScadaVersion { get; set; }
        /// <summary>
        /// 最后修改工程时间
        /// </summary>
        public string ModificationDateTime { get; set; }
        /// <summary>
        /// 最后修改工程的组态版本
        /// </summary>
        public string ModificationScadaVersion { get; set; }
        /// <summary>
        /// 工程唯一ID
        /// </summary>
        public string ProjectCode { get; set; }
        /// <summary>
        /// 分辨率
        /// </summary>
        public string ScreenSize { get; set; }
        /// <summary>
        /// 修改的计算机名
        /// </summary>
        public string ModifyComputer { get; set; }
        /// <summary>
        /// 编译时间
        /// </summary>
        public string CompileTime { get; set; }
        /// <summary>
        /// 编译唯一ID
        /// </summary>
        public string CompileGuid { get; set; }
        /// <summary>
        /// 工程大小
        /// </summary>
        public string ProjectSize { get; set; }
    }
}

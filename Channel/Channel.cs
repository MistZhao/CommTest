using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceDll;

namespace Channel
{
    public class Channel
    {
        #region 公有函数
        public Channel(string strChannelPath)
        {
            m_strChannelPath = strChannelPath;
            m_nPortNum = 0;
            m_objCommTypes.Clear();
        }

        public void SetCommTypes()
        {
            
        }

        public void SetProtocal(IProtocal objProtocal)
        {
            m_objProtocal = objProtocal;
        }

        public List<ICommType> GetCommTypes()
        {
            return m_objCommTypes;
        }
        #endregion

        #region 私有函数
        #endregion

        #region 变量
        private string m_strChannelPath;
        private int m_nPortNum;
        private List<ICommType> m_objCommTypes;
        private IProtocal m_objProtocal;
        #endregion
    }
}

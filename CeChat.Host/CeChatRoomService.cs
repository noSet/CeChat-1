﻿using System;
using System.Collections.Generic;
using CeChat.Model;
using CeChat.Service;

namespace CeChat.Host
{
    public class CeChatRoomService : MarshalByRefObject, ICeChatRoomService
    {
        /// <summary>
        /// 消息列表
        /// </summary>
        private readonly List<MessageInfo> _messageList = new List<MessageInfo>();

        /// <summary>
        /// 用户列表
        /// </summary>
        public List<string> UserList
        {
            get;
            set;
        }

        /// <summary>
        /// 用户加入
        /// </summary>
        /// <param name="userName"></param>
        public void Join(string userName)
        {
            if (this.UserList == null)
            {
                this.UserList = new List<string>();
            }

            this.UserList.Add(userName);
        }

        /// <summary>
        /// 用户离开
        /// </summary>
        /// <param name="userName"></param>
        public void Leave(string userName)
        {
            this.UserList.Remove(userName);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        public void ReceivingMessage(MessageInfo message)
        {
            this._messageList.Add(message);
        }

        /// <summary>
        /// 获取消息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MessageInfo> GetMessages()
        {
            //Thread.Sleep(2000);
            return this._messageList;
        }
    }
}

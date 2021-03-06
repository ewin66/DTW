﻿using System;
using System.Collections.Generic;
using System.Web;

namespace jdgl_res_head_service.上传下载流程说明
{
    /// <summary>
    /// 此类为说明类
    /// </summary>
    public class  SolutionInfo
    {
        /*信息的初始说明
         * 
         * 1.针对   酒店信息  协议单位信息  会员房价信息     
         * 初始化流程
         * 直接通过yydh来标识，先删除中心服务器上面的信息，然后上传本地库相关信息，成功后修改本地上传信息的shsc为1
         * 
         * 针对，房间类别的初始化，同时初始房间状态态(当前已对原来的程序做优化，修正为直接上传fjrb与FJZt两个表去server端一起处理)
         * 
         * 
        */



        /*信息的上传下载说明
         * 
         * 1.协议单位的上传下载说明
         * 上传时，分200百一次来传，避免数据量过大产生性能问题(and shsc=0 and rx='协议单位'")
         * 上传成功后，置M_Yxydw.xzxg = "xz",然后修改本地上传数据记录:shsc=1
         *          A.如果当前上传的数据，在中心服务器中的协议号能找到，直接更新为新的记录 
         *          B.如果当前上传的数据，在中心服务器中找不到，则直接新增
         * 
         * 下载
         * 条件   1. "yydh<>'" + yydh + "' and (clsj>='" + cstime + "' and clsj<'" + jstime + "' and rx='协议单位') or xzxg='xg'"
         *           2.上次的下载时间，如果没有，报错，不下载，定日志
         *           
         * 
         * 下载成功后
         *         根据协议号  改入到本地库
         *          存在协议号，修改本地库记录
         *          不存在协议号，直接新增进本地库
         *          以下成功，修改中心服务器的下载时间
         * 
         *2.协议房价的上传下载说明(协议房价为中心服务器统一管理)
         *    下载成功后（"yydh='" + yydh + "' and is_xz=0"）
         *         根据协议号  改入到本地库
         *          存在协议号，修改本地库记录
         *          不存在协议号，直接新增进本地库
         *           
         * 
         * 3.房间类型与维修房的处理
         *      取数  本地维修房与房间类型表上传到中央服务器
         *      a 处理上传维修房数据 
         *         建立维修房临时表,查找维修房当前记录在中心服务器是否存在,存在就更新记录；
         *                                                                                                      不存在新删除中心服务器记录信息
         *     
         *      b处理房间类型的数据
         *        建立临时表，查找当前中心服务器是否存在对应的记录,存在就修改为最新的
         *                  不存在，新增一条新的记录到中心服务器
         *        
         * 
         * 4.会员数据处理
         *      上传部分
         *          a." ID>=0 and yydh='" + yydh + "'  and shqr=1 and shsc=0"
         *          b." shxg=1  and shqr=1 and xgsj>='"+cssjtime+"'"
         *          (这里其它可以在系统里面，设置会员信息修改时，修改其shsc为0即可,上传部分就可以不再处理B的情况)
         *  
         * 5客史部分上传与下载
         *     上传部分:shsc=0
         *     
         *      下载部分
         *           
         */


        /* 订单的上传下载流程说明
         *     订单下载:
         *     "qymc='" + qymc + "'  and  sfqr='1'  and  shsc='0'"
         *     1.写入门库Qskyd表,同时修改中心服务器Web_skyd的shsc=1，表示下载完成
         *          A首先判断网上下载的主单 Web_skyd 如果为团体主单，先增加一个主单信息到本地表
         *          
         *          B查找 WebQskyd_fjrb表中的房间信息,
         *                 如果是散客，直接新增主单到本地表,同时修改中心服务器Web_skyd的shsc=1,表示下载完成
         *                 修改本地Qskyd_fjrb表fjrb，fjjg,并默认新增到Flfsz表中(由于本地主单的触发器的原因，会默认增加一条新的数据到Qskyd_fjrb表)
         *                 
         *                 如果是团队,考虑A中已经增加一条团体房类信息，第一条修改；其它的房类信息直接新增
         *                 
         * 注意：Web_skyd与WebQskyd_fjrb的shsc的标志均在新增主单到本地表后调用InsertToQyddjlsbhbg_yy 这个触发器里面置为1了
         *          
         *          
         *     
         
         
         
         
         */



    }
}
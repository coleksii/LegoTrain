﻿using Devkoes.Restup.WebServer.Attributes;
using Devkoes.Restup.WebServer.Models.Schemas;
using IoTCoreHelpers;
using LegoTrain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoTrain
{
    [RestController(InstanceCreationType.Singleton)]
    partial class TrainManagement
    {
        static private LegoInfrared myLego;
        static private Signal mySignal;
        static private Switch mySwitch;
        static private ParamRail myParamRail;

        public static async Task InitTrain()
        {
            myParamRail = await LoadParamRail();
            MySecurityKey = myParamRail.SecurityKey;
            securityKey = paramSecurityKey + ParamEqual + MySecurityKey;
            //// then Lego Infrared
            myLego = new LegoInfrared();
            // then Signal
            mySignal = new Signal(myParamRail.NumberOfSignals);
            mySwitch = new Switch(myParamRail.NumberOfSwitchs, myParamRail.MinDuration, myParamRail.MaxDuration, myParamRail.MinAngle, myParamRail.MaxAngle, myParamRail.ServoAngle);
        }

        private bool SecCheck(string strFilePath)
        {
            if (strFilePath.IndexOf(securityKey) == -1)
                return false;
            return true;

        }

        private string ErrorAuth()
        {
            string strResp = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">";
            strResp += "<html xmlns=\"http://www.w3.org/1999/xhtml\"><head><title>Gestion arrosage</title>";
            strResp += "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/></head>";
            strResp += "<meta http-equiv=\"Cache-control\" content=\"no-cache\"/>";
            strResp += "<meta http-equiv=\"EXPIRES\" content=\"0\" />";
            strResp += "<BODY><h1>RaspberryPi2 Lego Train running Windows 10</h1><p>";
            strResp += "Invalid security key</body></html>";
            return strResp;
        }

        [UriFormat("/util.aspx{param}")]
        public GetResponse Util(string param)
        {
            if (!SecCheck(param))
                return new GetResponse(GetResponse.ResponseStatus.OK, ErrorAuth());
            return ProcessUtil(param);
        }
        [UriFormat("/combo.aspx{param}")]
        public GetResponse Combo(string param)
        {
            if (!SecCheck(param))
                return new GetResponse(GetResponse.ResponseStatus.OK, ErrorAuth());
            return ProcessCombo(param);
        }
        [UriFormat("/comboall.aspx{param}")]
        public GetResponse ComboAll(string param)
        {
            if (!SecCheck(param))
                return new GetResponse(GetResponse.ResponseStatus.OK, ErrorAuth());
            return ProcessComboAll(param);
        }

        [UriFormat("/combopwm.aspx{param}")]
        public GetResponse ComboPWM(string param)
        {
            if (!SecCheck(param))
                return new GetResponse(GetResponse.ResponseStatus.OK, ErrorAuth());
            return ProcessComboPWM(param);
        }
        [UriFormat("/singlepwm.aspx{param}")]
        public GetResponse SinglePWM(string param)
        {
            if (!SecCheck(param))
                return new GetResponse(GetResponse.ResponseStatus.OK, ErrorAuth());
            return ProcessSinglePWM(param);
        }
        [UriFormat("/singlepwmall.aspx{param}")]
        public GetResponse SinglePWMAll(string param)
        {
            if (!SecCheck(param))
                return new GetResponse(GetResponse.ResponseStatus.OK, ErrorAuth());
            return ProcessSinglePWMAll(param);
        }
        [UriFormat("/singlecst.aspx{param}")]
        public GetResponse SingleCST(string param)
        {
            if (!SecCheck(param))
                return new GetResponse(GetResponse.ResponseStatus.OK, ErrorAuth());
            return ProcessSingleCST(param);
        }
        [UriFormat("/continuous.aspx{param}")]
        public GetResponse Continuous(string param)
        {
            if (!SecCheck(param))
                return new GetResponse(GetResponse.ResponseStatus.OK, ErrorAuth());
            return ProcessContinuous(param);
        }
        [UriFormat("/continuousall.aspx{param}")]
        public GetResponse ContinuousAll(string param)
        {
            if (!SecCheck(param))
                return new GetResponse(GetResponse.ResponseStatus.OK, ErrorAuth());
            return ProcessContinuousAll(param);
        }
        [UriFormat("/timeout.aspx{param}")]
        public GetResponse Timeout(string param)
        {
            if (!SecCheck(param))
                return new GetResponse(GetResponse.ResponseStatus.OK, ErrorAuth());
            return ProcessSingleTimeout(param);
        }
        [UriFormat("/switch.aspx{param}")]
        public GetResponse Switch(string param)
        {
            if (!SecCheck(param))
                return new GetResponse(GetResponse.ResponseStatus.OK, ErrorAuth());
            return ProcessSwitch(param);
        }
        [UriFormat("/signal.aspx{param}")]
        public GetResponse Signal(string param)
        {
            if (!SecCheck(param))
                return new GetResponse(GetResponse.ResponseStatus.OK, ErrorAuth());
            return ProcessSignal(param);
        }
        [UriFormat("/all.aspx{param}")]
        public GetResponse All(string param)
        {
            if (!SecCheck(param))
                return new GetResponse(GetResponse.ResponseStatus.OK, ErrorAuth());
            return ProcessDisplayAll(param);
        }
        [UriFormat("/circ.aspx{param}")]
        public GetResponse Circuit(string param)
        {
            if (!SecCheck(param))
                return new GetResponse(GetResponse.ResponseStatus.OK, ErrorAuth());
            return ProcessDisplayCircuit(param);
        }
        [UriFormat("/default.aspx{param}")]
        public GetResponse Default(string param)
        {
            if (!SecCheck(param))
                return new GetResponse(GetResponse.ResponseStatus.OK, ErrorAuth());
            return ProcessDisplayDefault(param);
        }
    }
       
}

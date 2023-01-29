import sys
import uuid
import requests as req

def Test():
    return 'Hello IronPython!'


def SysVersion():
    return sys.version


def CreateUUID():
    return str(uuid.uuid1())


def GetReqTest():
    res = req.get('https://httpbin.org/basic-auth/user/pass', auth=('user', 'pass'))
    return res.text

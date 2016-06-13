using System;

namespace TaoLa.AOPProxy
{
	public enum InterceptionType
	{
		OnEntry,
		OnExit,
		OnSuccess,
		OnException,
		OnLogException
	}
}
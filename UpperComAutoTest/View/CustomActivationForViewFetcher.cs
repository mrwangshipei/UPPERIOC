//using System;
//using System.Collections.Generic;
//using System.Reactive.Disposables;
//using System.Reactive.Linq;
//using ReactiveUI;
//using UpperComAutoTest.Page;

//// 实现 IActivationForViewFetcher 接口

//public class CustomActivationForViewFetcher : IActivationForViewFetcher
//{
//	public int GetAffinityForView(Type view)
//	{
//		// 检查传入的视图是否是我们感兴趣的视图类型
//		if (view == typeof(NomalComPage))
//		{
//			return 10; // 返回一个大于0的值表示我们支持这个视图
//		}

//		return 0; // 不支持的视图返回0
//	}

//	public IObservable<bool> GetActivationForView(IActivatableView view)
//	{
//		// 将传入的视图转换为 NomalComPage 类型
//		var normalComPage = view as NomalComPage;
//		if (normalComPage != null)
//		{
//			// 使用 ReactiveUI 的 View Activation 来检测
//			return Observable.Create<bool>(observer =>
//			{
//				// 标志位，防止递归
//				bool isActivated = false;
//observer.OnNext(true);
		

//				return Disposable.Empty;
//			});
//		}

//		// 如果视图不是我们感兴趣的类型，返回一个空的 Observable
//		return Observable.Empty<bool>();
//	}
//}
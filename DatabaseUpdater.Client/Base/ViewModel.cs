﻿using ReactiveUI;

namespace DatabaseUpdater.Core.Base
{
	public abstract class ViewModel<T> : ReactiveObject where T : ContentPage
	{
		protected T _Control;

		public ViewModel(T control) => _Control = control;
	}
}
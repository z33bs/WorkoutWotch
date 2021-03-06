﻿namespace WorkoutWotch.ViewModels
{
    using System;
    using Genesis.Ensure;
    using ReactiveUI;

    public sealed class MainViewModel : ReactiveObject, IScreen
    {
        private readonly Func<ExerciseProgramsViewModel> exerciseProgramsViewModelFactory;
        private readonly RoutingState router;

        public MainViewModel(
            Func<ExerciseProgramsViewModel> exerciseProgramsViewModelFactory)
        {
            Ensure.ArgumentNotNull(exerciseProgramsViewModelFactory, nameof(exerciseProgramsViewModelFactory));

            this.router = new RoutingState();
            this.exerciseProgramsViewModelFactory = exerciseProgramsViewModelFactory;
        }

        public RoutingState Router => this.router;

        public void Initialize() =>
            this
                .router
                .NavigateAndReset
                .Execute(exerciseProgramsViewModelFactory())
                .SubscribeSafe();
    }
}
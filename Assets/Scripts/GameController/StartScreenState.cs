using System;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace GameController
{
    public class StartScreenState : IState
    {
        private readonly GameObject startScreenCanvas;
        private readonly GameObject gameplayController;

        public StartScreenState(GameObject startScreenCanvas, GameObject gameplayController)
        {
            this.startScreenCanvas = startScreenCanvas;
            this.gameplayController = gameplayController;
        }
        
        public void Enter()
        {
            Debug.Log("Enter " + this.GetType().FullName);
            startScreenCanvas.SetActive(true);
            gameplayController.SetActive(false);
        }

        public void Exit()
        {
            Debug.Log("Exit " + this.GetType().FullName);
            startScreenCanvas.SetActive(false);
            gameplayController.SetActive(true);
        }

        private readonly List<Type> nextStates = new List<Type> {typeof(GameplayState), typeof(ExitingGameState)};

        public bool HasNextState(IState nextState)
        {
            return nextStates.Contains(nextState.GetType());
        }
    }
}
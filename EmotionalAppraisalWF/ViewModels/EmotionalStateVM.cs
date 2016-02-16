﻿using System.Collections.Generic;
using System.Linq;
using EmotionalAppraisal;
using EmotionalAppraisal.DTOs;
using Equin.ApplicationFramework;

namespace EmotionalAppraisalWF.ViewModels
{
    public class EmotionalStateVM
    {
        private EmotionalAppraisalAsset _emotionalAppraisalAsset;
        public BindingListView<EmotionDTO> Emotions {get;}

        public float Mood
        {
            get { return _emotionalAppraisalAsset.Mood; }
            set { _emotionalAppraisalAsset.Mood = value;}
        }

        public string Perspective
        {
            get { return _emotionalAppraisalAsset.Perspective; }
            set { _emotionalAppraisalAsset.Perspective = value; }
        }
          
        public EmotionalStateVM(EmotionalAppraisalAsset ea)
        {
            _emotionalAppraisalAsset = ea;

            Emotions = new BindingListView<EmotionDTO>(ea.ActiveEmotions.ToList());
        }
    }
}

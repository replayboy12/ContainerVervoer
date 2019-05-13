﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerLogic.Models
{
    public class Stack
    {
        private List<IContainer> containers;
        public IReadOnlyList<IContainer> Containers => containers;

        public Stack()
        {
            containers = new List<IContainer>();
        }

        public bool CanHoldWeight(IContainer container)
        {
            bool canHoldWeight = true;

            int shouldHold = container.TotalWeight;

            for (int i = containers.Count - 1; i >= 0 && canHoldWeight; i--)
            {
                IContainer c = containers[i];

                //if(shouldHold <= c.MaxHoldWeight)
                //{
                //    shouldHold += c.TotalWeight;
                //}
                //else
                //{
                //    canHoldWeight = false;
                //}

                canHoldWeight = c.CanHoldWeight(shouldHold);
            }

            return canHoldWeight;
        }

        public void Add(IContainer container)
        {
            containers.Add(container);
        }

        public void Reset()
        {
            containers.Clear();
        }

        public int TotalWeight()
        {
            int totalWeight = 0;
            foreach(IContainer c in containers)
            {
                totalWeight += c.TotalWeight;
            }
            return totalWeight;
        }
    }
}

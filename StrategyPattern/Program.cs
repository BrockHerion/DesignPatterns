using System;
using StrategyPattern;


var mallard = new MallardDuck();
mallard.PerformQuack();
mallard.PerformFly();

var model = new ModelDuck();
model.PerformFly();
model.FlyBehavior = new FlyPoweredRocket();
model.PerformFly();

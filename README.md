# Head First Design Patterns - C\#

Head First Design Patterns is a fantastic look at the various design patterns used in Object Oriented Programming. The samples in book were all written in Java, which is fine, but I myself prefer C\# for an OO language.

Thus, I have taken it upon myself to do the book examples in .NET 5 and C\# instead of Java. My solutions are free to be cloned, picked at, and experimented with. Enjoy!

## Chapter 1 - Strategy Pattern

This pattern is useful for selecting an algorithm to use at runtime. In the example from the book, we have an issue where we have all kinds of ducks. The ducks all have the same kind of base behaviors but each does it a little differently. This is where the Strategy Pattern comes in. We can create a whole slew of similar behaviors and assign them to our ducks! Mallard ducks can fly and quack while model ducks can't. We can do things to make the model duck fly though, say, strapping a rocket on it's back.

In practice, it works like this:

```cs
public interface ISomeBehavior {
    void SomeMethod();
}
```

We are creating a base behavior interface that all of our implementations  must follow.

```cs
public class GoodBehavior : ISomeBehavior {
    public void SomeMethod() {
        Console.WriteLine("Good!")
    }
}

public class BadBehavior : ISomeBehavior {
    public void SomeMethod() {
        Console.WriteLine("Bad!")
    }
}

```

Now we need some kind of object to use these behaviors

```cs
public class MyModel {
    public ISomeBehavior Behavior { get; set; }

    // Rest of class omitted

    public void PerformBehavior() {
        Behavior.SomeMethod();
    }
}
```

Here's where the rubber meets the road. Let's use these behaviors with our model!

```cs
var model = new MyModel { 
    Behavior = new GoodBehavior()
};

model.PerformBehavior();
// Output: Good!

model.Behavior = new BadBehavior();
model.PerformBehavior();
// Output: Bad!

```

And just like that, we implemented the Strategy Pattern!

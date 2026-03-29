using NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;
  }


  public class FA1
  {
    public static State start = new State()
    {
      Name = "start",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State initialZero = new State()
    {
      Name = "initialZero",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State initialOne = new State()
    {
      Name = "initialOne",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State tooManyZeroes = new State()
    {
      Name = "tooManyZeroes",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public State correct = new State()
    {
      Name = "correct",
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };
    State InitialState = start;
    public FA1()
    {
      start.Transitions['0'] = initialZero;
      start.Transitions['1'] = initialOne;
      initialZero.Transitions['0'] = tooManyZeroes;
      initialZero.Transitions['1'] = correct;
      initialOne.Transitions['0'] = correct;
      initialOne.Transitions['1'] = initialOne;
      tooManyZeroes.Transitions['0'] = tooManyZeroes;
      tooManyZeroes.Transitions['1'] = tooManyZeroes;
      correct.Transitions['0'] = tooManyZeroes;
      correct.Transitions['1'] = correct;
    }
    public bool? Run(IEnumerable<char> s)
    {
      State current = InitialState;
      foreach (var c in s)
      {
        current = current.Transitions[c];
        if (current == null) return null;
      }
      return current.IsAcceptState;
    }
  }

  public class FA2
  {
    public static State evenZeroesEvenOnes = new State()
    {
      Name = "evenZeroesEvenOnes",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public static State oddZeroesEvenOnes = new State()
    {
      Name = "oddZeroesEvenOnes",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public static State evenZeroesOddOnes = new State()
    {
      Name = "evenZeroesOddOnes",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public static State oddZeroesOddOnes = new State()
    {
      Name = "oddZeroesOddOnes",
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };
    State InitialState = evenZeroesEvenOnes;
    public FA2()
    {
      evenZeroesEvenOnes.Transitions['0'] = oddZeroesEvenOnes;
      evenZeroesEvenOnes.Transitions['1'] = evenZeroesOddOnes;
      oddZeroesEvenOnes.Transitions['0'] = evenZeroesEvenOnes;
      oddZeroesEvenOnes.Transitions['1'] = oddZeroesOddOnes;
      evenZeroesOddOnes.Transitions['0'] = oddZeroesOddOnes;
      evenZeroesOddOnes.Transitions['1'] = evenZeroesEvenOnes;
      oddZeroesOddOnes.Transitions['0'] = evenZeroesOddOnes;
      oddZeroesOddOnes.Transitions['1'] = oddZeroesEvenOnes;
    }
    public bool? Run(IEnumerable<char> s)
    {
      State current = InitialState;
      foreach (var c in s)
      {
        current = current.Transitions[c];
        if (current == null) return null;
      }
      return current.IsAcceptState;
    }
  }
  
  public class FA3
  {
    public static State noOne = new State()
    {
      Name = "noOne",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public static State oneOne = new State()
    {
      Name = "oneOne",
      IsAcceptState = false,
      Transitions = new Dictionary<char, State>()
    };
    public static State twoOnes = new State()
    {
      Name = "twoOnes",
      IsAcceptState = true,
      Transitions = new Dictionary<char, State>()
    };
    State InitialState = noOne;
    public FA3()
    {
      noOne.Transitions['0'] = noOne;
      noOne.Transitions['1'] = oneOne;
      oneOne.Transitions['0'] = noOne;
      oneOne.Transitions['1'] = twoOnes;
      twoOnes.Transitions['0'] = twoOnes;
      twoOnes.Transitions['1'] = twoOnes;
    }
    public bool? Run(IEnumerable<char> s)
    {
      State current = InitialState;
      foreach (var c in s)
      {
        current = current.Transitions[c];
        if (current == null) return null;
      }
      return current.IsAcceptState;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      UnitTest1 test = new UnitTest1();
      test.TestMethod1();
      test.TestMethod2();
      test.TestMethod3();
      test.TestMethod4();
      test.TestMethod5();
      test.TestMethod6();
      test.TestMethod7();
      test.TestMethod8();
      test.TestMethod9();
      test.TestMethod10();
      test.TestMethod11();
      test.TestMethod12();
      test.TestMethod13();
      test.TestMethod14();
      test.TestMethod15();
      test.TestMethod16();
      test.TestMethod17();
      test.TestMethod18();
      test.TestMethod19();
      test.TestMethod20();
      test.TestMethod21();
      Console.WriteLine("Testing successful!\nInput your string:");
      string s = Console.ReadLine();
      FA1 fa1 = new FA1();
      bool? result1 = fa1.Run(s);
      Console.WriteLine(result1);
      FA2 fa2 = new FA2();
      bool? result2 = fa2.Run(s);
      Console.WriteLine(result2);
      FA3 fa3 = new FA3();
      bool? result3 = fa3.Run(s);
      Console.WriteLine(result3);
    }
  }
}

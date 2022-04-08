using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApp1
{

  public class Ingredient
  {
    public Ingredient(){ }
    public Ingredient(string Name, int Calories)
    {
      this.Name = Name;
      this.Calories = Calories;
    }
    public string Name { get;set; }
    public int Calories { get; set; }
  }

  class Program
  {
    static void Main(string[] args)
    {
      functionCincoEspression();
    }

    #region Fluent_Expression
    /**
     * Existen dos formas de crear consultas en LINQ
     * Fluent
     * Expression
    */

    public static void functionCincoEspression()
    {
      Ingredient[] ingredientes = {
        new Ingredient{Name= "Pan",Calories=200 },
        new Ingredient{Name= "Te",Calories=20 },
        new Ingredient{Name= "Pure",Calories=300 },
        new Ingredient{Name= "Carne de pollo",Calories=250 }
      };

      Ingredient[] ingrePorConstructor = {
        new Ingredient("jalea", 200),
        new Ingredient("queso", 200)
      };

      IEnumerable<string> highCalorieIngredientNamesQuery = from i in ingredientes
                                                            where i.Calories >= 150
                                                            orderby i.Name
                                                            select i.Name;

      foreach (var element in highCalorieIngredientNamesQuery)
      {
        Console.WriteLine("highCalorieIngredientNamesQuery: " + element);
      }


    }

    public static void functionCincoFluent()
    {
      Ingredient[] ingredientes = {
        new Ingredient{Name= "Pan",Calories=200 },
        new Ingredient{Name= "Te",Calories=20 },
        new Ingredient{Name= "Pure",Calories=300 },
        new Ingredient{Name= "Carne de pollo",Calories=250 }
      };

      Ingredient[] ingrePorConstructor = {
        new Ingredient("jalea", 200),
        new Ingredient("queso", 200)
      };

      IEnumerable<string> highCalorieIngredientNamesQuery = ingredientes.Where(i => i.Calories > 150)
                                                                        .OrderBy(i => i.Name)
                                                                        .Select(i => i.Name);

      foreach (var element in highCalorieIngredientNamesQuery)
      {
        Console.WriteLine("highCalorieIngredientNamesQuery: " + element);
      }

      IEnumerable<string> highCalorieIngredientNamesQueryContructor = ingrePorConstructor.Where(i => i.Calories > 150)
                                                                  .OrderBy(i => i.Name)
                                                                  .Select(i => i.Name);

      foreach (var element in highCalorieIngredientNamesQueryContructor)
      {
        Console.WriteLine("highCalorieIngredientNamesQueryContructor: " + element);
      }

    }

    #endregion

    #region FuncionesXML
    public static void functionCuatro()
    {
      var xml = @"
        <ingredients>
        <ingredient name='milk' quantity='200' price='2.99' />
        <ingredient name='sugar' quantity='100' price='4.99' />
        <ingredient name='safron' quantity='1' price='46.77' />
        </ingredients>";

      XElement xmlData = XElement.Parse(xml);

      XElement milk = xmlData.Descendants("ingredient").First(x => x.Attribute("name").Value == "milk");

      XAttribute nameAttribute = milk.FirstAttribute;
      XAttribute priceAttribute = milk.Attribute("price");
      string priceOfMilk = priceAttribute.Value; // 2.99
      XAttribute quantity = milk.Attributes().Skip(1).First();


      Console.WriteLine(quantity);
    }
    #endregion

    #region FuncionesArray
    public static void functionTres()
    {
      int[] fibonacci = { 0, 1, 1, 2, 3, 5 };

      IEnumerable<int> numbersGreaterThanTwoQuery = fibonacci.Where(num => num > 2).ToArray();


      fibonacci[0] = 99;

      foreach (int element in numbersGreaterThanTwoQuery)
      {
        Console.WriteLine(element);
      }
    }

    public static void functionDos()
    {
      int[] fibonacci = { 0, 1, 1, 2, 3, 5 };

      IEnumerable<int> numbersGreaterThanTwoQuery = fibonacci.Where(x => x > 2);

      Console.WriteLine("Elements in output sequence:");

      foreach (var element in numbersGreaterThanTwoQuery)
      {
        Console.WriteLine(element);
      }
    }

    public static void functionUno()
    {
      int[] fibonacci = { 0, 1, 1, 2, 3, 5 };

      int numeroElementos = fibonacci.Count();

      IEnumerable<int> distincNumbers = fibonacci.Distinct();

      Console.WriteLine("Elements in output sequence:");

      foreach (var element in distincNumbers)
      {
        Console.WriteLine(element);
      }
    }

    #endregion

  }
}

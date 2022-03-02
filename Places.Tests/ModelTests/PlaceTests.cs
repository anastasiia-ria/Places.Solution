using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Places.Models;
using System.Collections.Generic;

namespace Places.Tests
{
  [TestClass]
  public class PlaceTests : IDisposable
  {
    public void Dispose()
    {
      Place.ClearAll();
    }
    [TestMethod]
    public void PlaceConstructor_CreatesInstanceOfPlace_Place()
    {
      Place newPlace = new Place("test");
      Assert.AreEqual(typeof(Place), newPlace.GetType());
    }
    [TestMethod]
    public void GetDescription_Returns_Description_String()
    {
      string description = "Walk the dog.";
      Place newPlace = new Place(description);
      string result = newPlace.Description;
      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      string description = "Walk the dog.";
      Place newPlace = new Place(description);
      string updatedDescription = "Do the dishes.";
      newPlace.Description = updatedDescription;
      string result = newPlace.Description;
      Assert.AreEqual(updatedDescription, result);
    }
    [TestMethod]
    public void GetAll_ReturnsEmptyList_PlaceList()
    {
      List<Place> newList = new List<Place> { };
      List<Place> result = Place.GetAll();
      foreach (Place thisPlace in result)
      {
        Console.WriteLine("Output from empty list GetAll test: " + thisPlace.Description);
      }
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void GetAll_ReturnsPlaces_PlaceList()
    {
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Place newPlace1 = new Place(description01);
      Place newPlace2 = new Place(description02);
      List<Place> newList = new List<Place>{
        newPlace1, newPlace2
      };

      List<Place> result = Place.GetAll();
      foreach (Place thisPlace in result)
      {
        Console.WriteLine("Output from second GetAll test: " + thisPlace.Description);
      }
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_PlacesInstantiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      string description = "Walk the dog.";
      Place newPlace = new Place(description);

      //Act
      int result = newPlace.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectPlace_Place()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Place newPlace1 = new Place(description01);
      Place newPlace2 = new Place(description02);

      //Act
      Place result = Place.Find(2);

      //Assert
      Assert.AreEqual(newPlace2, result);
    }
  }
}
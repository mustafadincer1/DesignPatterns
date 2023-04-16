using System;

public class DataProcessor
{
    public string[] ProcessData(string[] data)
    {
        string[] processedData = new string[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
            processedData[i] = data[i].ToUpper(); // Converting to uppercase
        }

        return processedData;
    }
}

public class DataHandler
{
    public string[] GetData()
    {
        // Code for getting data from external source
        // ...
        string[] data = { "apple", "banana", "cherry" };
        return data;
    }

    public void StoreData(string[] data)
    {
        // Code for storing data to external destination
        // ...
        Console.WriteLine("Data stored successfully!");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        DataProcessor processor = new DataProcessor();
        DataHandler handler = new DataHandler();

        string[] data = handler.GetData();
        string[] processedData = processor.ProcessData(data);
        handler.StoreData(processedData);
    }
}

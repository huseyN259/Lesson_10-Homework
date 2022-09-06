class Document
{
	public static DocumentProgram? CreateDocument(string type)
	{
		return type switch
		{
			"DocumentProgram" => new DocumentProgram(),
			"ProDocumentProgram" => new ProDocumentProgram(),
			"ExpertDocument" => new ExpertDocument(),
			_ => null
		};
	}
}

class DocumentProgram
{
	public void OpenDocument() => Console.WriteLine("Document Openned");
	public virtual void EditDocument() => Console.WriteLine("Can Edit in Pro and Expert versions");
	public virtual void SaveDocument() => Console.WriteLine("Can Save in Pro and Expert versions");
}

class ProDocumentProgram : DocumentProgram
{
	public sealed override void EditDocument() => Console.WriteLine("Document Edited");
	public sealed override void SaveDocument() => Console.WriteLine("Document Saved in doc format, for pdf format buy Expert packet");
}

class ExpertDocument : DocumentProgram
{
	public sealed override void EditDocument() => Console.WriteLine("Document Edited");
	public sealed override void SaveDocument() => Console.WriteLine("Document Saved in pdf format");
}

class Program
{
	static void Main()
	{
		var answers = new string[] { "Pro Document Program", "Expert Document", "Document Program" };

		while (true)
		{
			int choice = (int)Control.GetSelect("\n~ Please, Enter Your Choice :\n", answers, true);
			
			if (choice == -1) 
				break;

			DocumentProgram? dc = Document.CreateDocument(answers[choice].Replace(" ", string.Empty));

			dc?.OpenDocument();
			dc?.EditDocument();
			dc?.SaveDocument();

			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();
		}
	}
}
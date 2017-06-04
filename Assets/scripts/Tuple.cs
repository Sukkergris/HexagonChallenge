using System;

public class Tuple
{
	public HexCell TranserFrom { get; private set; }
	public int Amount { get; private set; }
	public HexCell TranserTo { get; private set; }

	public Tuple (HexCell transerFrom, int amount, HexCell transferTo)
	{
		TranserFrom = transerFrom;
		Amount = amount;
		TranserTo = transferTo;
	}
}


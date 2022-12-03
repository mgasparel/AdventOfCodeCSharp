namespace AdventOfCode2022;

public class ElfGroup
{
    private readonly IList<Rucksack> _rucksacks;

    public int PriorityOfBadge()
    {
        char duplicate = Rucksack.DetermineDuplicate(
            _rucksacks[0].Contents,
            _rucksacks[1].Contents,
            _rucksacks[2].Contents);

        return Rucksack.GetPriority(duplicate);
    }

    public ElfGroup(IList<Rucksack> rucksacks)
    {
        _rucksacks = rucksacks;
    }
}
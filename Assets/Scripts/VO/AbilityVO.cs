namespace MMCL.VO
{
	public class AbilityVO
	{
		public int Id { get; private set; }

		public string Name { get; private set; }
		public string Explain { get; private set; }

		public static AbilityVO Create(int id)
		{
			var vo = new AbilityVO();
			vo.Id = id;

			return vo;
		}
	}
}

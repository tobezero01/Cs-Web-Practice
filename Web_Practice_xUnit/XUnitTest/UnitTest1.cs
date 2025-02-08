namespace XUnitTest
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			// arrange
			MyMath mm = new MyMath();

			int a = 1, b = 2;
			int expectedValue = 3;
			// Act
			int c = mm.add(a, b);

			// Assert

			Assert.Equal(c, expectedValue);
		}
	}
}
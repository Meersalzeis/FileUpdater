namespace KaiFileUpdater;


class FileUpdaterRegistration
{
	public void accept(FileUpdaterVisitor FUVisitor)
	{
		FUVisitor.visit(this);
	}
}
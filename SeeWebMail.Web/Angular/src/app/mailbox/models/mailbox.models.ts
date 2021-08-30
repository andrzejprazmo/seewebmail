export interface FolderContract {
  folderName: string,
  folderType: number,
}

export interface MailHeaderContract {
  index: number,
  subject: string,
}

export 
  interface MailPackageContract {
  totalCount: number;
  pageSize: number;
  list: MailHeaderContract[],
}

export 
  interface MailBodyContract extends MailHeaderContract {
  content: string;
}


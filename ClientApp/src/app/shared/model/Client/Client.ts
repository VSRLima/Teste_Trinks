import { IClient } from './IClient';

export class Client implements IClient
{
  public id: number;
  public Name: string;
  public cnpj: string;
  public state: string;
}

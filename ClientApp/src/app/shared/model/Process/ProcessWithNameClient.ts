import { IProcess } from './IProcess';

export class ProcessWithNameClient implements IProcess
{
  public id: number;
  public active: boolean;
  public processNumber: string;
  public state: string;
  public monetaryValue: number;
  public startDate : Date;
  public clientId: number;
  public clientName: string;
}

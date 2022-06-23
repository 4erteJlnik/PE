export class Post{
    public date:Date | undefined;
    constructor(public name:string, public cost:Number,public dateOfCreate:string,public id:string,public creatorId:string){
    
    }
}
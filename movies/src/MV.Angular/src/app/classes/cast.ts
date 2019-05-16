import { JsonObject, JsonProperty } from 'json2typescript';

@JsonObject('Cast')
export class Cast {

    @JsonProperty('cast_Id', Number, true)
    Cast_Id: number = undefined;

    @JsonProperty('character', String, true)
    Character: string = undefined;

    @JsonProperty('credit_Id', String, true)
    Credit_Id: string = undefined;

    @JsonProperty('id', Number, true)
    Id: number = undefined;
    
    @JsonProperty('gender', Number, true)
    Gender: number = undefined;
    
    @JsonProperty('name', String , true)
    Name: string = undefined;

    @JsonProperty('order', Number, true)
    Order: number = undefined;

    @JsonProperty('profile_Path', String, true)
    Profile_Path: string = undefined;
}
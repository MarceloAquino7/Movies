import { JsonObject, JsonProperty, Any } from 'json2typescript';

@JsonObject('Crew')
export class Crew {

    @JsonProperty('credit_Id', Any, true)
    Credit_Id: any = undefined;

    @JsonProperty('department', String, true)
    Department: string = undefined;

    @JsonProperty('gender', Number, true)
    Gender: number = undefined;

    @JsonProperty('id', Number, true)
    Id: number = undefined;
    
    @JsonProperty('job', String, true)
    Job: string = undefined;
    
    @JsonProperty('name', String, true)
    Name: string = undefined;

    @JsonProperty('profile_Path', String, true)
    Profile_Path: string = undefined;
}
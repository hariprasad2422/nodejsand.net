using Microsoft.AspNetCore.Mvc;
[ApiController][Route("api/images")]
public class ImagesController:ControllerBase{
static List<dynamic> imgs=new();
[HttpGet] public IActionResult Get()=>Ok(imgs);
[HttpPost] public async Task<IActionResult> Post(IFormFile file){
if(file==null)return BadRequest();
Directory.CreateDirectory("uploads");
var id=Guid.NewGuid().ToString();
var name=id+Path.GetExtension(file.FileName);
using var fs=System.IO.File.Create(Path.Combine("uploads",name));
await file.CopyToAsync(fs);
var obj=new{id,name=file.FileName,url=$"/uploads/{name}"};
imgs.Add(obj); return Ok(obj);}
[HttpDelete("{id}")]
public IActionResult Delete(string id){
var item=imgs.FirstOrDefault(x=>x.id==id);
if(item!=null) imgs.Remove(item);
return NoContent();}}
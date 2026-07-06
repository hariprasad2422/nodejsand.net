import {useEffect,useState} from 'react';import axios from 'axios';
export default function App(){const[f,setF]=useState();const[i,setI]=useState([]);
const load=()=>axios.get('http://localhost:5000/api/images').then(r=>setI(r.data)).catch(()=>{});
useEffect(load,[]);
const up=async()=>{const d=new FormData();d.append('file',f);await axios.post('http://localhost:5000/api/images',d);load();}
const del=async(id)=>{await axios.delete('http://localhost:5000/api/images/'+id);load();}
return <div style={{padding:20}}><h1>Image Uploader</h1><input type='file' onChange={e=>setF(e.target.files[0])}/><button onClick={up}>Upload</button>{i.map(x=><div key={x.id}><img src={'http://localhost:5000'+x.url} width='120'/><button onClick={()=>del(x.id)}>Delete</button></div>)}</div>}
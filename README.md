
#Select Query

query{
  brands{
    name
  }
}

#Create Mutation

mutation { 
  createUser (
    user:{
      id:5,
      name:"test"
    }
  )
  {
    name
  } 
}

#Delete Mutation 

mutation {
  deleteUser(id:5) {
    name
    id
  }
}

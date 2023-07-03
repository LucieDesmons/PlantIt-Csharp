
const BuildSchema = mongoose.Schema(
    {
      nom: { type: String },
      espece: { type: String },
      eclairement: { type: Number },
      humidite: { type: Number },
      emplacement: { type: String },
      container: { type: String }
    },
    { timestamps: true }
  );

const BuildSchema = mongoose.Schema(
    {
      prenom: { type: String },
      nom: { type: String },
      email: { type: Object },
      tel: { type: Number },
      pseudo: { type: String },
      password: { type: String }
    },
    { timestamps: true }
  );
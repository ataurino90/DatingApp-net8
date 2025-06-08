export interface Message {
  id: number
  sendertId: number
  senderUsername: string
  senderPhotoUrl: string
  recipientId: number
  recipientUsername: string
  recipientPhotoUrl: string
  content: string
  dateRead?: Date
  messageSent: Date
}
